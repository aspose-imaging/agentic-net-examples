using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                TiffFrame firstFrame = new TiffFrame(tiffOptions, width, height);
                Graphics gFirst = new Graphics(firstFrame);
                gFirst.Clear(Color.White);

                using (TiffImage tiffImage = new TiffImage(firstFrame))
                {
                    int additionalPages = 2;
                    for (int i = 0; i < additionalPages; i++)
                    {
                        TiffFrame blankFrame = new TiffFrame(tiffOptions, width, height);
                        Graphics gBlank = new Graphics(blankFrame);
                        gBlank.Clear(Color.White);
                        tiffImage.AddFrame(blankFrame);
                    }

                    tiffImage.Save();
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
 * 1. When a CAD system exports a single‑page CMX drawing and the workflow requires a multi‑page TIFF for archival, a developer can use this code to convert the CMX to a TIFF and add blank pages for future annotations.
 * 2. When an automated document processing pipeline needs to pad a single‑page CMX image with extra pages to meet a fixed page count before sending it to a printing service, this snippet creates the multi‑page TIFF with white pages.
 * 3. When a medical imaging application stores legacy CMX scans but the hospital information system only accepts multi‑page TIFF files, the code enables conversion and insertion of placeholder pages.
 * 4. When a batch job generates CMX files for each design step and the final report must contain a TIFF file with a title page and separator pages, developers can use this example to add those blank pages programmatically.
 * 5. When a cloud‑based image conversion service offers users the option to download their single‑page CMX as a multi‑page TIFF for compatibility with document viewers, this C# routine performs the conversion and adds the required empty pages.
 */