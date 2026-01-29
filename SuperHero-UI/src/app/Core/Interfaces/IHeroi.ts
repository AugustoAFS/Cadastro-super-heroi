import { ISuperpoder } from "./ISuperpoder";

export interface IHeroi {
    id: number;
    nome: string;
    nomeHeroi: string;
    dataNascimento?: Date;
    altura: number;
    peso: number;
    superpoderes?: ISuperpoder[];
}
