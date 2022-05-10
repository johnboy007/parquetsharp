using System.Collections.Generic;
using System.IO;

namespace ParquetMapper;

public interface IParquetMapper
{
    List<AmdiMasterSetDto> Map(Stream stream);

    IEnumerable<AmdiMasterSetPartialDto> MapPartialIds(Stream stream);
}