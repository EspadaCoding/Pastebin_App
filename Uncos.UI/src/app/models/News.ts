export interface News {  
    id: string;
    userId: string;
    title: string;
    content: string;
    poster: string;
    username: string;
    likes: number;
    itSaved: boolean;
    itLiked: boolean;
    createdDate: Date;
    categoryId: string;
    countofComments: number; 
}