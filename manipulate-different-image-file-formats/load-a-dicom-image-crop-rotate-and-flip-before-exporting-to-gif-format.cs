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
            string outputPath = "Output\\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                // Crop 10 pixels from each side
                dicom.Crop(10, 10, 10, 10);

                // Rotate 45 degrees clockwise, resize proportionally, white background
                dicom.Rotate(45f, true, Color.White);

                // Flip horizontally
                dicom.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Save as GIF
                GifOptions gifOptions = new GifOptions();
                dicom.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}