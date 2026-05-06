using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of DICOM files to process
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.dcm",
                @"C:\Images\image2.dcm",
                @"C:\Images\image3.dcm"
            };

            foreach (var inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PDF path (same folder, same name with .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure load options for memory optimization (256 KB buffer)
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024
                };

                // Load the DICOM image using the specified load options
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Set up PDF export options
                    var pdfOptions = new PdfOptions();

                    // Save the image as a PDF file
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}