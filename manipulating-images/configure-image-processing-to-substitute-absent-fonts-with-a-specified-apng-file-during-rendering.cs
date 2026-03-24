using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputVectorPath = "input.svg";
        string fontFolderPath = "fonts";
        string placeholderApngPath = "placeholder.apng";
        string outputApngPath = "output.apng";
        string tempRasterPath = "temp.png";

        // Validate input files
        if (!File.Exists(inputVectorPath))
        {
            Console.Error.WriteLine($"File not found: {inputVectorPath}");
            return;
        }
        if (!File.Exists(placeholderApngPath))
        {
            Console.Error.WriteLine($"File not found: {placeholderApngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

        // Load vector image with custom fonts
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource(
            args =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0)
                {
                    string fontsPath = args[0]?.ToString() ?? string.Empty;
                    if (Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            byte[] fontBytes = File.ReadAllBytes(fontFile);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                        }
                    }
                }
                return fonts.ToArray();
            },
            fontFolderPath);

        using (Image vectorImage = Image.Load(inputVectorPath, loadOptions))
        {
            // Prepare vector rasterization options
            var vectorRasterOpts = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None
            };

            // Rasterize vector image to a temporary PNG
            var pngCreateOptions = new PngOptions
            {
                Source = new FileCreateSource(tempRasterPath, false),
                VectorRasterizationOptions = vectorRasterOpts
            };
            vectorImage.Save(tempRasterPath, pngCreateOptions);
        }

        // Load rasterized vector frame and placeholder APNG frame
        using (RasterImage rasterFrame = (RasterImage)Image.Load(tempRasterPath))
        using (RasterImage placeholderFrame = (RasterImage)Image.Load(placeholderApngPath))
        {
            // Create APNG image
            var apngCreateOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputApngPath, false),
                DefaultFrameTime = 500,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, rasterFrame.Width, rasterFrame.Height))
            {
                apngImage.RemoveAllFrames();
                apngImage.AddFrame(rasterFrame);
                apngImage.AddFrame(placeholderFrame);
                apngImage.Save();
            }
        }

        // Clean up temporary raster file
        if (File.Exists(tempRasterPath))
        {
            File.Delete(tempRasterPath);
        }
    }
}