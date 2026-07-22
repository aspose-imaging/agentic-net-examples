using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.wmf";
        string outputPath = "Output\\sample.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set custom font folder
            string customFontFolder = "Fonts";
            FontSettings.SetFontsFolders(new string[] { customFontFolder }, true);

            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = wmfImage.Size,
                    RenderMode = WmfRenderMode.Auto
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                wmfImage.Save(outputPath, pngOptions);
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
 * 1. When a C# application must render legacy WMF diagrams that use corporate brand fonts stored in a private Fonts folder, the code sets the custom font path before converting the WMF to PNG.
 * 2. When generating thumbnails of WMF icons for a web portal that relies on non‑system fonts, developers use this snippet to load the fonts from a specific directory and rasterize the image.
 * 3. When automating batch conversion of WMF reports on a build server that does not have the required TrueType fonts installed, the code points FontSettings to a bundled font folder to ensure accurate rendering.
 * 4. When creating printable PNG assets from WMF files in a multi‑tenant SaaS solution, each tenant can supply its own font collection, and the code loads those fonts before rasterization.
 * 5. When converting WMF graphics in a Windows service that runs under a restricted user account lacking access to system fonts, the developer supplies a custom font directory to avoid missing‑glyph errors.
 */