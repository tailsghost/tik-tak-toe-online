import { GameStatus } from "./repositories/game";


export type GameEntity =
  | GameIdleEntity
  | GameInProgressEntity
  | GameOverEntity
  | GameOverDrawEntity;

export type PlayerEntity = {
  id: string;
  login: string;
  rating: number;
};

export type GameIdleEntity = {
  id: string;
  creator: PlayerEntity;
  status: GameStatus.idle;
};

export type GameInProgressEntity = {
  id: string;
  players: PlayerEntity[];
  field: Field;
  status: GameStatus.inProgress;
};

export type GameOverEntity = {
  id: string;
  players: PlayerEntity[];
  field: Field;
  status: GameStatus.gameOver;
  winner?: PlayerEntity;
};

export type GameOverDrawEntity = {
  id: string;
  players: PlayerEntity[];
  field: Field;
  status: GameStatus.gameOverDraw;
};

export type Field = (GameSymbol | null)[];
export type GameSymbol = string;
