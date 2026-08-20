namespace API.Utils
{
    public class ModelEnums
    {
        public enum Entities
        {
            Author = 1,
            Book = 2,
            Comic = 3,
            Video = 4,
            Music = 5,
            Games = 6
        }
        public enum StorageType
        {
            Database = 0,
            FileSystem = 1
        }
        public enum ReadingStatus
        {
            MaybeRead = 0,
            ToRead = 1,
            Reading = 2,
            ReReading = 3,
            OnHold = 4,
            WaitingCompletion = 5,
            Finished = 6,
            Abandoned = 7,
        }

        public enum WritingStatus
        {
            InProgress = 0,
            Hiatus = 1,
            Finished = 2,
            Abandoned = 3,
        }
    }
}
