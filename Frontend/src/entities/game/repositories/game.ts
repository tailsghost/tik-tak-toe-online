import api from "@/utils/axiosInstance";
import { GET_GAME_LIST } from "@/config/GlobalAPIConfig";
import {
  GameEntity,
  GameIdleEntity,
  GameInProgressEntity,
  GameOverDrawEntity,
  GameOverEntity,
  PlayerEntity,
} from "../domain";
import { z } from "zod";

type ServerGame = Game & {
  players: User[];
  winner?: User | null;
};

type Game = {
  id: string;
  name: string;
  players: User[];
  status: GameStatus;
  winner: User;
  field?: string;
  gameOverAt?: string;
};

export enum GameStatus {
  idle,
  inProgress,
  gameOver,
  gameOverDraw,
}

type User = {
  id: string;
  login: string;
  rating: number;
  games: Game[];
  winnerGames: Game[];
};

async function getGames(): Promise<GameEntity[]> {
  try {
    const response = await api.get<ServerGame[]>(GET_GAME_LIST);
    const data = response.data as (Game & {
      players: User[];
      winner?: User | null;
    })[];
    return data.map(ServerGameToGameEntity);
  } catch (error) {
    console.log("Ошибка при загрузке игр:", error);
    return [];
  }
}

function toPlayerEntities(users: User[]): PlayerEntity[] {
  return users.map((user) => ({
    id: user.id,
    login: user.login,
    rating: user.rating,
  }));
}

const fieldScheme = z.array(z.union([z.string(), z.null()]));

function ServerGameToGameEntity(
  game: Game & {
    players: User[];
    winner?: User | null;
  }
): GameEntity {
  switch (game.status) {
    case GameStatus.idle: {
      const [creator] = game.players;
      if(!creator) {
        throw new Error("Создатель должен быть в idle!")
      }
      return {
        id: game.id,
        creator: creator,
        status: game.status,
      } satisfies GameIdleEntity;
    }
    case GameStatus.inProgress:
    case GameStatus.gameOverDraw: {
      return {
        id: game.id,
        players: toPlayerEntities(game.players),
        status: game.status,
        field: fieldScheme.parse(game.field),
      }
    }
    case GameStatus.gameOver: {
      if (!game.winner) {
        throw new Error("Победитель должен быть в законченной игре!");
      }

      return {
        id: game.id,
        players: toPlayerEntities(game.players),
        status: game.status,
        field: fieldScheme.parse(game.field),
      } satisfies GameOverEntity;
    }
  }
}
