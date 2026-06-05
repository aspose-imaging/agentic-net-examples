using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output\\preview.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (Image epsImg = Image.Load(inputPath))
            {
                // Cast to EpsImage (full namespace used to avoid extra using)
                var epsImage = epsImg as Aspose.Imaging.FileFormats.Eps.EpsImage;
                if (epsImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not an EPS image.");
                    return;
                }

                // Extract the TIFF preview using the enumeration
                using (Image preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF))
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No TIFF preview available in the EPS file.");
                        return;
                    }

                    // Save the preview as a TIFF file
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    preview.Save(outputPath, tiffOptions);
                }
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
 * 1. When a graphic designer needs to extract the embedded TIFF preview from an EPS file to generate a quick thumbnail for a web gallery using C# and Aspose.Imaging.
 * 2. When a publishing workflow requires converting EPS preview images to TIFF format for high‑resolution print proofs without rendering the full vector content.
 * 3. When a document management system must validate that an EPS file contains a preview and store that preview as a TIFF for archival and search indexing.
 * 4. When a batch‑processing script has to automate the extraction of EPS previews and save them as TIFF files to ensure compatibility with legacy imaging software.
 * 5. When a .NET application needs to display EPS preview images in a Windows Forms UI by first converting the preview to a TIFF that can be loaded by standard image controls.
 */