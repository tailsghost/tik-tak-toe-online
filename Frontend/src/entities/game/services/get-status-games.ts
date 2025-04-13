import api from "@/utils/axiosInstance";
import { GET_GAME_IDLE_LIST } from "@/config/GlobalAPIConfig";
import { GameIdleEntity } from "../domain";
import { GameStatus } from "../repositories/game";


export async function getIdleGames() :Promise<GameIdleEntity[]> {
    try {
        const response = await api.get<GameIdleEntity[]>(`${GET_GAME_IDLE_LIST}`);
       return response.data;
    } catch (error) {
        console.error("Ошибка загрузки игр", error)
        return [];
    }     
}