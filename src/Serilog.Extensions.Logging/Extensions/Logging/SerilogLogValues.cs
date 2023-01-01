// Copyright 2019 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Serilog.Events;
using System;
using System.Collections;
using System.Collections.Generic;
#if NET45
using IReadOnlyList =global::System.Collections.Generic.IReadOnlyList<System.Collections.Generic.KeyValuePair<string, object>>;
#endif

namespace Serilog.Extensions.Logging
{
    readonly struct SerilogLogValues :
#if NET40 || NET35
        IList<KeyValuePair<string, object>>
#elif NET45
        IReadOnlyList
#else
        System.Collections.Generic.IReadOnlyList<System.Collections.Generic.KeyValuePair<string, object>>
#endif
    {
        // Note, this struct is only used in a very limited context internally, so we ignore
        // the possibility of fields being null via the default struct initialization.

        private readonly MessageTemplate _messageTemplate;
        private readonly
#if NET40 || NET35
            IDictionary<string, LogEventPropertyValue> _properties;
#else
            IReadOnlyDictionary<string, LogEventPropertyValue> _properties;
#endif
        private readonly KeyValuePair<string, object>[] _values;
        /// <summary>
        /// The is read only
        /// </summary>
        private readonly bool _isReadOnly;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogValues"/> struct.
        /// </summary>
        /// <param name="messageTemplate">The message template.</param>
        /// <param name="properties">The properties.</param>
        /// <exception cref="System.ArgumentNullException">messageTemplate</exception>
        /// <exception cref="System.ArgumentNullException">properties</exception>
        public SerilogLogValues(MessageTemplate messageTemplate,
#if NET40 || NET35
            IDictionary<string, LogEventPropertyValue> properties)
#else
            IReadOnlyDictionary<string, LogEventPropertyValue> properties)
#endif
        {
            _messageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));

            // The dictionary is needed for rendering through the message template
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));

            // The array is needed because the IReadOnlyList<T> interface expects indexed access
            _values = new KeyValuePair<string, object>[_properties.Count + 1];
            var i = 0;
            foreach (var p in properties)
            {
                _values[i] = new KeyValuePair<string, object>(p.Key, (p.Value is ScalarValue sv) ? sv.Value : p.Value);
                ++i;
            }
            _values[i] = new KeyValuePair<string, object>("{OriginalFormat}", _messageTemplate.Text);
            _isReadOnly = true;
        }

        public int IndexOf(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }


        public KeyValuePair<string, object> this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public int Count => _properties.Count + 1;

        public bool IsReadOnly
        {
            get => _isReadOnly;
            set => throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => ((IEnumerable<KeyValuePair<string, object>>)_values).GetEnumerator();

        public override string ToString() => _messageTemplate.Render(_properties);

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
    }
}
