using System;
using System.Collections.Generic;

namespace JSONLib
{
    public interface IJSON
    {
        IJSON Add(String key, String value);
        IJSON Add(String key, params string[] values);
        IJSON Add(String key, int value);
        IJSON Add(String key, int[] values);
        IJSON Add(String key, double value);
        IJSON Add(String key, double[] values);
        IJSON Add(String key, List<String> values);
        IJSON Merge(IJSON json);
        IJSON Merge(IJSON[] jsons);
        IJSON Clear();
        List<String> Keys();
        String GetFormatted();
        int Length();
    }
}
