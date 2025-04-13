import { Game } from "@/interfaces/Game";
import api from "@/utils/axiosInstance";
import { GET_GAME_LIST } from "@/config/GlobalAPIConfig";

export async function getGames(): Promise<Game[]> {
  try {
    const response = await api.get<Game[]>(GET_GAME_LIST);
    return response.data;
  } catch (error) {
    console.log("Ошибка при загрузке игр:", error);
    return [];
  }
}
