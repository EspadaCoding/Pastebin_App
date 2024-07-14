export interface News {  
    id: string;
    userId: string;
    title: string;
    content: string;
    poster: string;
    likes: number;
    itSaved: boolean;
    createdDate: Date;
    categoryId: string;
    countofComments: number; 
}