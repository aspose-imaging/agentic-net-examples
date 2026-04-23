using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DjVu document from the input file stream
            using (Stream inputStream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
            {
                // Access the first page (index 0)
                var djvuPage = djvuImage.Pages[0];

                // Save the page to a memory stream as PNG
                using (MemoryStream pngStream = new MemoryStream())
                {
                    djvuPage.Save(pngStream, new PngOptions());
                    pngStream.Position = 0; // Reset stream position for reading

                    // Load the PNG image from the memory stream
                    using (Image pngImage = Image.Load(pngStream))
                    {
                        // Define the rectangle area to extract (x=50, y=50, width=300, height=300)
                        var exportArea = new Rectangle(50, 50, 300, 300);

                        // Crop the image to the specified rectangle
                        pngImage.Crop(exportArea);

                        // Save the cropped image to the output path as PNG
                        pngImage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}