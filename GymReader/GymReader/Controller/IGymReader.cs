using System.Collections.Generic;
using System.Data;

namespace GymReader.Controller
{
    public interface IGymReader
    {
        List<DataTable> ReadScheda(string schedaPath);
    }
}