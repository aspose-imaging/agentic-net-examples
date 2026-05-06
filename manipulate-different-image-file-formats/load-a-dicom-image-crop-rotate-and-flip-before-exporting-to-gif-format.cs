using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load DICOM image
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                // Crop: remove 10 pixels from each side
                int cropLeft = 10;
                int cropTop = 10;
                int cropWidth = dicom.Width - 20;
                int cropHeight = dicom.Height - 20;
                var cropRect = new Rectangle(cropLeft, cropTop, cropWidth, cropHeight);
                dicom.Crop(cropRect);

                // Rotate 45 degrees clockwise, resize proportionally, white background
                dicom.Rotate(45f, true, Color.White);

                // Flip horizontally
                dicom.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Save as GIF
                var gifOptions = new GifOptions();
                dicom.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}