using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input WebP file and output PDF file paths
        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        // Load the WebP image (Aspose.Imaging automatically detects the format)
        using (Image image = Image.Load(inputPath))
        {
            // Set up PDF options; KeepMetadata ensures original image metadata is preserved
            PdfOptions pdfOptions = new PdfOptions
            {
                KeepMetadata = true
            };

            // Save the loaded image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}