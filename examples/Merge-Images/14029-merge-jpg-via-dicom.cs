using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <input1.jpg> <input2.jpg> ... <output.dcm>");
            return;
        }

        string outputPath = args[args.Length - 1];
        List<string> inputPaths = new List<string>();
        for (int i = 0; i < args.Length - 1; i++)
        {
            inputPaths.Add(args[i]);
        }

        List<Aspose.Imaging.Size> sizeList = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizeList.Add(img.Size);
            }
        }

        int newWidth = 0;
        int newHeight = 0;
        foreach (Aspose.Imaging.Size sz in sizeList)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight)
                newHeight = sz.Height;
        }

        Source fileSource = new FileCreateSource(outputPath, false);
        DicomOptions dicomOptions = new DicomOptions { Source = fileSource };

        using (DicomImage canvas = (DicomImage)Image.Create(dicomOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            canvas.Save();
        }
    }
}