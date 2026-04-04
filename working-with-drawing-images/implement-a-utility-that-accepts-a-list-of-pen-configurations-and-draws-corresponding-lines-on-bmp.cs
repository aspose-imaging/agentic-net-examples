using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class PenConfig
{
    public Aspose.Imaging.Color Color { get; set; }
    public float Width { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }
}

class Program
{
    // Hardcoded input and output paths
    private const string InputPath = "input.txt";
    private const string OutputPath = "output.bmp";

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

        // Parse pen configurations from the input file
        var penConfigs = ParsePenConfigurations(InputPath);
        if (penConfigs == null || penConfigs.Length == 0)
        {
            Console.Error.WriteLine("No valid pen configurations found.");
            return;
        }

        // Define image size (could be parameterized)
        const int imageWidth = 800;
        const int imageHeight = 600;

        // Create BMP image
        var bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(OutputPath, false)
        };

        using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
        {
            // Initialize graphics surface
            var graphics = new Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw each line according to its pen configuration
            foreach (var cfg in penConfigs)
            {
                var pen = new Pen(cfg.Color, cfg.Width);
                graphics.DrawLine(pen, cfg.X1, cfg.Y1, cfg.X2, cfg.Y2);
            }

            // Save the image (the file is already created by FileCreateSource, but Save finalizes it)
            image.Save();
        }
    }

    // Reads the input file and returns an array of PenConfig objects.
    // Expected line format (comma‑separated):
    // ColorName,Width,X1,Y1,X2,Y2
    // Example:
    // Red,2,10,10,200,200
    private static PenConfig[] ParsePenConfigurations(string path)
    {
        var lines = File.ReadAllLines(path);
        var list = new System.Collections.Generic.List<PenConfig>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 6)
                continue; // skip malformed lines

            var color = GetColorByName(parts[0].Trim());
            if (!float.TryParse(parts[1].Trim(), out float width))
                continue;
            if (!int.TryParse(parts[2].Trim(), out int x1) ||
                !int.TryParse(parts[3].Trim(), out int y1) ||
                !int.TryParse(parts[4].Trim(), out int x2) ||
                !int.TryParse(parts[5].Trim(), out int y2))
                continue;

            list.Add(new PenConfig
            {
                Color = color,
                Width = width,
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2
            });
        }

        return list.ToArray();
    }

    // Retrieves an Aspose.Imaging.Color by name using reflection.
    // Falls back to Black if the name is not found.
    private static Aspose.Imaging.Color GetColorByName(string name)
    {
        var prop = typeof(Aspose.Imaging.Color).GetProperty(name,
            BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
        if (prop != null && prop.PropertyType == typeof(Aspose.Imaging.Color))
        {
            return (Aspose.Imaging.Color)prop.GetValue(null);
        }

        // Attempt to parse as ARGB hex (e.g., #FF112233)
        if (name.StartsWith("#") && int.TryParse(name.Substring(1), System.Globalization.NumberStyles.HexNumber, null, out int argb))
        {
            return Aspose.Imaging.Color.FromArgb(argb);
        }

        // Default fallback
        return Aspose.Imaging.Color.Black;
    }
}