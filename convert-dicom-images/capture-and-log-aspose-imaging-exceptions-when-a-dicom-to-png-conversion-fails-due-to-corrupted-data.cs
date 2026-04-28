using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch any unexpected exception
        try
        {
            // Hardcoded input DICOM file path
            string inputPath = "input.dcm";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory where PNG files will be written
            string outputDirectory = "output";

            // Load the DICOM image from file stream to respect memory limits if needed
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // No special load options are required for this example
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page in the DICOM file
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build output file name for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                        // Ensure the output directory exists (creates it if missing)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        try
                        {
                            dicomPage.Save(outputPath, new PngOptions());
                        }
                        catch (PngImageException pngEx)
                        {
                            Console.Error.WriteLine($"PNG conversion error on page {dicomPage.Index}: {pngEx.Message}");
                        }
                        catch (ImageSaveException saveEx)
                        {
                            Console.Error.WriteLine($"Image save error on page {dicomPage.Index}: {saveEx.Message}");
                        }
                    }
                }
            }
        }
        catch (DicomImageException dicomEx)
        {
            // Specific handling for corrupted DICOM data
            Console.Error.WriteLine($"DICOM processing error: {dicomEx.Message}");
        }
        catch (Exception ex)
        {
            // General fallback for any other unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}