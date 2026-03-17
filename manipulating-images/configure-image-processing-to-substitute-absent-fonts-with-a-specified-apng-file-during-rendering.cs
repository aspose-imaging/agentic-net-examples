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
        string vectorPath = "input.svg";
        string outputApngPath = "output.apng";
        string fontFolderPath = "fonts";

        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource((object[] fontArgs) =>
        {
            string fontsPath = fontArgs.Length > 0 ? fontArgs[0]?.ToString() : string.Empty;
            var fontList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
            {
                foreach (var file in Directory.GetFiles(fontsPath))
                {
                    byte[] data = File.ReadAllBytes(file);
                    string name = Path.GetFileNameWithoutExtension(file);
                    fontList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                }
            }
            return fontList.ToArray();
        }, fontFolderPath);

        using (Image vectorImage = Image.Load(vectorPath, loadOptions))
        {
            var vectorRasterOpts = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            using (var memoryStream = new MemoryStream())
            {
                var pngOpts = new PngOptions { VectorRasterizationOptions = vectorRasterOpts };
                vectorImage.Save(memoryStream, pngOpts);
                memoryStream.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                {
                    var apngOpts = new ApngOptions
                    {
                        Source = new FileCreateSource(outputApngPath, false),
                        DefaultFrameTime = 100,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOpts, raster.Width, raster.Height))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(raster);
                        apng.Save();
                    }
                }
            }
        }
    }
}