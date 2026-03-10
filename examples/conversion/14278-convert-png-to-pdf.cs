using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load the PNG image from disk
        using (Image image = Image.Load("input.png"))
        {
            // Create PDF saving options
            var pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF file
            image.Save("output.pdf", pdfOptions);
        }
    }
}