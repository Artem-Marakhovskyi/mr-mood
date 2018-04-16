
export class Song {
    constructor(
        public songTitle : string,
        public meanTempo : number,
        public meanEnergy : number,
        public id : number,
        public artistTitle : string,
        public duration : number,
        public fileName : string,
        public tags : string[]) {
    }
}