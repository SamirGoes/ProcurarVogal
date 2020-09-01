using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurarVogal
{
    public class MyStream : IStream
    {
        private readonly string _input;

        private bool _hasNext;
        private int _index;
        private int _inputLenght;
        public char _current;

        public MyStream(string input)
        {
            this._input = input;

            this._index = 0;
            this._hasNext = false;
            this._inputLenght = _input.Length;
        }

        public unsafe char getNext()
        {
            fixed (char* array = _input)
            {
                _current = array[_index];
                _index++;
            }

            return _current;
        }

        public bool hasNext()
        {
            this._hasNext = _index < _inputLenght;
            return this._hasNext;
        }

        public override string ToString() => _input;
    }
}
