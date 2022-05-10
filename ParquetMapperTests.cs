using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParquetMapper;

[Collection("ParquetMapperTests")]
public class ParquetMapperTests
{
    private const string ParquetsTestFullSnappyParquet = "part-00000.snappy.parquet";


    [Fact]
    public async Task ParquetMapper_WithDelta_Returns18265_FullDtos()
    {
        //Act
        const int expected = 18265;
        await using Stream fileStream = File.OpenRead(ParquetsTestFullSnappyParquet);
        var parquetMapper = new ParquetMapper();

        //Arrange
        var mapProductAndCatalogs = parquetMapper.Map(fileStream);

        //Assert
        Assert.Equal(expected, mapProductAndCatalogs.Count());
    }

    [Fact]
    public async Task ParquetMapper_WithFull_Returns18265_PartialDtos()
    {
        // Act
        const int expected = 18265;
        await using Stream fileStream = File.OpenRead(ParquetsTestFullSnappyParquet);
        var parquetMapper = new ParquetMapper();

        // Arrange
        var mapProductAndCatalogs = parquetMapper.MapPartialIds(fileStream);

        // Assert
        Assert.Equal(expected, mapProductAndCatalogs.Count());
    }
}