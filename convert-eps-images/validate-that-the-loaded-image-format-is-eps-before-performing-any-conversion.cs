using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (!(image is EpsImage epsImage))
                {
                    Console.Error.WriteLine("Loaded image is not an EPS file.");
                    return;
                }

                epsImage.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to convert client‑uploaded EPS logos to PNG thumbnails, it must first verify the file is truly an EPS image to avoid processing invalid formats.
 * 2. When an automated batch job processes a folder of design assets, checking that each file is an EPS before conversion prevents runtime errors and ensures only vector graphics are rasterized.
 * 3. When generating printable PDFs that embed PNG versions of EPS illustrations, the code validates the source EPS format to guarantee the correct rendering pipeline is used.
 * 4. When a content management system allows users to replace EPS diagrams with PNG previews, confirming the original file type protects against accidental uploads of unsupported image types.
 * 5. When a CI/CD pipeline validates graphic assets before deployment, the EPS format check ensures that only approved vector files are converted to PNG for use in the final product.
 */