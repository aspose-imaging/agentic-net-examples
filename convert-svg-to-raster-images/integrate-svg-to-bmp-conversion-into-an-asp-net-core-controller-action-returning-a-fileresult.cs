using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image and save as BMP
        using (Image image = Image.Load(inputPath))
        {
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                }
            };

            image.Save(outputPath, bmpOptions);
        }
    }
}

// ASP.NET Core controller that returns the converted BMP as a file result
public class SvgToBmpController : Microsoft.AspNetCore.Mvc.ControllerBase
{
    // GET /api/svg-to-bmp
    public Microsoft.AspNetCore.Mvc.IActionResult ConvertSvgToBmp()
    {
        // Hardcoded input and output paths (same as in Main)
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return NotFound($"Input file not found: {inputPath}");
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image and save as BMP
        using (Image image = Image.Load(inputPath))
        {
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                }
            };

            image.Save(outputPath, bmpOptions);
        }

        // Return the BMP file to the client
        byte[] fileBytes = System.IO.File.ReadAllBytes(outputPath);
        return new Microsoft.AspNetCore.Mvc.FileContentResult(fileBytes, "image/bmp")
        {
            FileDownloadName = Path.GetFileName(outputPath)
        };
    }
}