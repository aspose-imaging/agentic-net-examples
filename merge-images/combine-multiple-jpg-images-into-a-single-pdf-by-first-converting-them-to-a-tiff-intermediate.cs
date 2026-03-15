using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // args[0] - folder containing JPG files
        // args[1] - output PDF file path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputFolder> <outputPdfPath>");
            return;
        }

        string inputFolder = args[0];
        string outputPdfPath = args[1];
        string tempTiffPath = Path.Combine(Path.GetTempPath(), "intermediate.tif");

        string[] jpgFiles = Directory.GetFiles(inputFolder, "*.jpg");
        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found in the specified folder.");
            return;
        }

        // Load the first image to obtain dimensions
        using (Image firstImg = Image.Load(jpgFiles[0]))
        {
            RasterImage firstRaster = (RasterImage)firstImg;
            int width = firstRaster.Width;
            int height = firstRaster.Height;

            // Configure TIFF options for the intermediate file
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(tempTiffPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create a multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Add the first frame
                TiffFrame firstFrame = new TiffFrame(firstRaster);
                tiffImage.AddFrame(firstFrame);

                // Remove the default empty frame created by Image.Create
                TiffFrame defaultFrame = tiffImage.ActiveFrame;
                tiffImage.ActiveFrame = tiffImage.Frames[1];
                tiffImage.RemoveFrame(0);
                defaultFrame.Dispose();

                // Add remaining JPG images as frames
                for (int i = 1; i < jpgFiles.Length; i++)
                {
                    using (Image img = Image.Load(jpgFiles[i]))
                    {
                        RasterImage raster = (RasterImage)img;
                        TiffFrame frame = new TiffFrame(raster);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the multi‑frame TIFF as a PDF
                tiffImage.Save(outputPdfPath, new PdfOptions());
            }
        }

        // Cleanup temporary TIFF file
        if (File.Exists(tempTiffPath))
        {
            File.Delete(tempTiffPath);
        }
    }
}