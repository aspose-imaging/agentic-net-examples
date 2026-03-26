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
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
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
            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // For each DICOM page, save as PNG (here we handle the first page)
                foreach (var dicomPage in dicomImage.DicomPages)
                {
                    // Save the page as PNG
                    dicomPage.Save(outputPath, new PngOptions());
                    // If only the first page is needed, break after saving
                    break;
                }
            }
        }
        // Capture specific Aspose.Imaging exceptions
        catch (DicomImageException ex)
        {
            Console.Error.WriteLine($"Dicom image error: {ex.Message}");
        }
        catch (ImageSaveException ex)
        {
            Console.Error.WriteLine($"Image save error: {ex.Message}");
        }
        catch (PngImageException ex)
        {
            Console.Error.WriteLine($"PNG image error: {ex.Message}");
        }
        // Capture any other unexpected exceptions
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}