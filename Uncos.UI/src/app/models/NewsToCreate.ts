export class NewsToCreate {  
    title: string;
    content: string;
    poster: string; 
    categoryid:string;
    constructor(){ 
         this.title = "";
         this.content = "";
         this.poster = ""; 
         this.categoryid = ""; 
    }
}