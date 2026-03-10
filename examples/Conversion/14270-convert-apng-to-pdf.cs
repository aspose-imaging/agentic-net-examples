using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load the APNG raster image from file
        using (Image apngImage = Image.Load("input.apng"))
        {
            // Save the loaded image as a PDF document
            // PdfOptions can be customized if needed; default options are used here
            apngImage.Save("output.pdf", new PdfOptions());
        }
    }
}