using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage source = (TiffImage)Image.Load(inputPath))
            {
                int frameCount = source.Frames.Length;
                TiffFrame[] frames = new TiffFrame[frameCount];
                for (int i = 0; i < frameCount; i++)
                {
                    frames[i] = TiffFrame.CopyFrame(source.Frames[i]);
                }

                BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
                using (BigTiffImage bigTiff = new BigTiffImage(frames))
                {
                    bigTiff.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}