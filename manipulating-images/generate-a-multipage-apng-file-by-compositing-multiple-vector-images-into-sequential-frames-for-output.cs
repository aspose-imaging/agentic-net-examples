using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] vectorFiles = new string[]
        {
            "vector1.svg",
            "vector2.svg",
            "vector3.svg"
        };

        string outputPath = "output.apng";

        Source fileSource = new FileCreateSource(outputPath, false);

        ApngOptions apngCreateOptions = new ApngOptions
        {
            Source = fileSource,
            DefaultFrameTime = 100,
            ColorType = PngColorType.TruecolorWithAlpha
        };

        using (Image firstVector = Image.Load(vectorFiles[0]))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions pngOpts = new PngOptions();
                firstVector.Save(ms, pngOpts);
                ms.Position = 0;

                using (RasterImage firstRaster = (RasterImage)Image.Load(ms))
                {
                    int canvasWidth = firstRaster.Width;
                    int canvasHeight = firstRaster.Height;

                    using (ApngImage apng = (ApngImage)Image.Create(apngCreateOptions, canvasWidth, canvasHeight))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(firstRaster);

                        for (int i = 1; i < vectorFiles.Length; i++)
                        {
                            using (Image vectorImg = Image.Load(vectorFiles[i]))
                            {
                                using (MemoryStream msFrame = new MemoryStream())
                                {
                                    vectorImg.Save(msFrame, pngOpts);
                                    msFrame.Position = 0;

                                    using (RasterImage rasterFrame = (RasterImage)Image.Load(msFrame))
                                    {
                                        apng.AddFrame(rasterFrame);
                                    }
                                }
                            }
                        }

                        apng.Save();
                    }
                }
            }
        }
    }
}