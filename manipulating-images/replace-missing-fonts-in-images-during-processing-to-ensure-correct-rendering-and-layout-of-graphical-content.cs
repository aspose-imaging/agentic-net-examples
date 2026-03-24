using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.CustomFontHandler;

class Program
{
    // Hardcoded input and output paths
    private const string InputPath = "input.emf";
    private const string OutputPath = "output.png";
    // Folder that contains the replacement fonts
    private const string FontsFolder = "fonts";

    static void Main()
    {
        // Verify input file exists
        if (!File.Exists(InputPath))
        {
            Console.Error.WriteLine($"File not found: {InputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

        // Preserve original font folders to restore later
        string[] originalFontFolders = FontSettings.GetFontsFolders();

        try
        {
            // Point Aspose.Imaging to the folder with replacement fonts
            FontSettings.SetFontsFolder(FontsFolder);
            // Update internal cache so the new fonts are recognized
            FontSettings.UpdateFonts();

            // Load the EMF/WMF image with a custom font source (optional, demonstrates alternative approach)
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, FontsFolder);

            using (Image image = Image.Load(InputPath, loadOptions))
            {
                // If the image is a vector format, we can inspect used/missed fonts
                if (image is MetaImage metaImage)
                {
                    string[] usedFonts = metaImage.GetUsedFonts();
                    string[] missedFonts = metaImage.GetMissedFonts();

                    Console.WriteLine("Used fonts:");
                    foreach (var f in usedFonts) Console.WriteLine($"  {f}");

                    Console.WriteLine("Missed fonts (should be resolved by custom source):");
                    foreach (var f in missedFonts) Console.WriteLine($"  {f}");
                }

                // Convert the vector image to a raster format (PNG) using vector rasterization options
                var rasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image
                image.Save(OutputPath, pngOptions);
            }
        }
        finally
        {
            // Restore original font folders
            FontSettings.SetFontsFolders(originalFontFolders, true);
        }
    }

    // Custom font source that reads all font files from the specified folder
    private static CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = args.Length > 0 ? args[0]?.ToString() ?? string.Empty : string.Empty;
        var fontDataList = new System.Collections.Generic.List<CustomFontData>();

        if (Directory.Exists(fontsPath))
        {
            foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                byte[] fontBytes = File.ReadAllBytes(fontFile);
                fontDataList.Add(new CustomFontData(fontName, fontBytes));
            }
        }

        return fontDataList.ToArray();
    }
}