using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

string inputPath = @"C:\temp\input.webp";   // Path to the source WebP image
string outputPath = @"C:\temp\output.pdf"; // Desired PDF output path

// Load the WebP image using the WebPImage constructor (load rule)
using (WebPImage webPImage = new WebPImage(inputPath))
{
    // Save the active frame of the WebP image to a PDF document (save rule)
    webPImage.Save(outputPath, new PdfOptions());
}