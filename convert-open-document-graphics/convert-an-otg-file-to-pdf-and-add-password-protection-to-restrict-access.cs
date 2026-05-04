using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // Password protection for PDF is not supported by Aspose.Imaging.
                throw new NotSupportedException("Password protection for PDF is not supported by Aspose.Imaging.");

                // image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}