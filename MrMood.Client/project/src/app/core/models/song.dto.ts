export class SongDto {
    constructor(
        public id : number,
        public songTitle : string,
        public artistTitle : string,
        public duration : number,
        public fileName : string,
        public tags : string[],
        public meanTempo : number,
        public meanEnergy : number
    ) {

    }
}