using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image, apply transformations, and save as GIF
        using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
        {
            // Crop the image (example values)
            int leftShift = 10;
            int rightShift = 10;
            int topShift = 10;
            int bottomShift = 10;
            dicom.Crop(leftShift, rightShift, topShift, bottomShift);

            // Rotate the image 45 degrees clockwise, resize proportionally, white background
            dicom.Rotate(45f, true, Color.White);

            // Flip horizontally
            dicom.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Save the transformed image as GIF
            GifOptions gifOptions = new GifOptions();
            dicom.Save(outputPath, gifOptions);
        }
    }
}