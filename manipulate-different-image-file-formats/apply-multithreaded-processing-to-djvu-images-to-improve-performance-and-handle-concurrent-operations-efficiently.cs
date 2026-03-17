using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string dir = @"c:\temp\";

        // Load the DjVu document from a file stream.
        using (Stream stream = File.OpenRead(Path.Combine(dir, "sample.djvu")))
        {
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Process each page concurrently.
                Parallel.ForEach(djvuImage.Pages, pageObj =>
                {
                    // The Pages collection returns Image objects; cast to DjvuPage.
                    DjvuPage page = (DjvuPage)pageObj;

                    // Build the output file name based on the page number.
                    string fileName = $"sample.{page.PageNumber}.png";
                    string outputPath = Path.Combine(dir, fileName);

                    // Save the page as a PNG image.
                    page.Save(outputPath, new PngOptions());
                });
            }
        }
    }
}