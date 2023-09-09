namespace Catalog.API.Entities
{
    public class Image
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        //public string ContentType { get; set; }
        public byte[] Data { get; set; }
        //public Extension Extension { get; set; }
        //public ImageSaveTo SavedTo { get; set; } = ImageSaveTo.Database;
        public Product Product { get; set; }
        public long ProductId { get; set; }
    }
}
