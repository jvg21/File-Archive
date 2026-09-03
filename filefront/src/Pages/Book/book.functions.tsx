import type { BookEntity } from "../../Data/Types/Entity/book.entity";

export function generateEmptyBook(): BookEntity {
    return {
        id:-1,
        name: "",
        summary: "",
        currentChapter: 0,
        totalChapters: 0,
        words: 0,
        writingStatus: 0,
        readingStatus: 0,
        urls: [],
        files: [],
        authors: []
    }
}