using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.pdf";
            string outputPath = "Output/cleaned.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a JPEG thumbnail of a PDF document for display in a web portal, they can use Aspose.Imaging to load the PDF page and save it as a JPEG image.
 * 2. When an automated reporting system must embed a PDF chart into an email as an image attachment, the code converts the PDF page to a JPEG that email clients can render without requiring a PDF viewer.
 * 3. When a legacy application only supports raster images for printing, developers can convert each PDF page to a high‑quality JPEG using Aspose.Imaging’s JpegOptions before sending it to the printer.
 * 4. When a document management workflow requires storing visual previews of uploaded PDFs in a database, the code extracts the first page and saves it as a JPEG for quick indexing and search.
 * 5. When a mobile app needs to display PDF content offline, developers can pre‑process the PDFs on the server by converting pages to JPEG files with Aspose.Imaging, reducing file size and simplifying rendering on the device.
 */