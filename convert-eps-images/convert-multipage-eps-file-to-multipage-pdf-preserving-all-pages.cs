using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "multipage_input.eps";
        string outputPath = "multipage_output.pdf";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (handles null directory case)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image (cast to EpsImage) and save as multipage PDF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to the specific EPS image type
            var epsImage = image as Aspose.Imaging.FileFormats.Eps.EpsImage;
            if (epsImage == null)
            {
                Console.Error.WriteLine("The loaded file is not a valid EPS image.");
                return;
            }

            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save all pages of the EPS to the PDF
            epsImage.Save(outputPath, pdfOptions);
        }
    }
}