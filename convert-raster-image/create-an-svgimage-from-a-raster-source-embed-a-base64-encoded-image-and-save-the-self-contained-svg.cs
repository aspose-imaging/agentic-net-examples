using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string rasterPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.svg";

            // Verify input file exists
            if (!File.Exists(rasterPath))
            {
                Console.Error.WriteLine($"File not found: {rasterPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load raster image to obtain its dimensions
            int width, height;
            using (Image rasterImage = Image.Load(rasterPath))
            {
                width = rasterImage.Width;
                height = rasterImage.Height;
            }

            // Read raster image bytes and convert to Base64
            byte[] rasterBytes = File.ReadAllBytes(rasterPath);
            string base64Data = Convert.ToBase64String(rasterBytes);
            string mimeType = "image/png"; // Adjust if using a different raster format

            // Build SVG content with embedded Base64 image
            string svgContent = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg xmlns=""http://www.w3.org/2000/svg"" width=""{width}"" height=""{height}"">
    <image href=""data:{mimeType};base64,{base64Data}"" width=""{width}"" height=""{height}"" />
</svg>";

            // Load SVG from the generated string
            using (var svgStream = new MemoryStream(Encoding.UTF8.GetBytes(svgContent)))
            using (var svgImage = new SvgImage(svgStream))
            {
                // Save the self‑contained SVG
                svgImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}