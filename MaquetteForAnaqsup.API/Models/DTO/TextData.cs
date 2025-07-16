namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class TextData
    {
        public string Text { get; set; }
    }

    public class ProcessedTextData : TextData
    {
        public string[] NormalizedTokens { get; set; }
        public string[] StemmedTokens { get; set; }
        public float[] TFIDFFeatures { get; set; }
    }
}
