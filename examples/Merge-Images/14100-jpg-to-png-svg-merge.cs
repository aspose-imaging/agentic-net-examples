using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

// Define input JPG and output PNG paths
string dir = @"c:\temp\";
string jpgPath = Path.Combine(dir, "input.jpg");
string pngPath = Path.Combine(dir, "merged_output.png");

// Load the JPG image to obtain its dimensions
using (Image jpgImage = Image.Load(jpgPath))
{
    int width = jpgImage.Width;
    int height = jpgImage.Height;

    // Read JPG bytes and convert to Base64 for embedding in SVG
    byte[] jpgBytes = File.ReadAllBytes(jpgPath);
    string base64Jpg = Convert.ToBase64String(jpgBytes);

    // Create an SVG document that embeds the JPG as a base64‑encoded image
    string svgXml = $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"{height}\">" +
                    $"<image href=\"data:image/jpeg;base64,{base64Jpg}\" width=\"{width}\" height=\"{height}\"/>" +
                    $"</svg>";

    // Load the SVG from a memory stream
    using (MemoryStream svgStream = new MemoryStream(Encoding.UTF8.GetBytes(svgXml)))
    using (SvgImage svgImage = new SvgImage(svgStream))
    {
        // Configure rasterization options to match the original dimensions
        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
        {
            PageSize = new Size(width, height)
        };

        // Set PNG save options with the rasterization settings
        PngOptions pngOptions = new PngOptions
        {
            VectorRasterizationOptions = rasterOptions
        };

        // Save the rasterized SVG as a PNG file
        svgImage.Save(pngPath, pngOptions);
    }
}