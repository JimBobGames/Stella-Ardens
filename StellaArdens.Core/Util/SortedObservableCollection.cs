﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://stackoverflow.com/questions/19112922/sort-observablecollectionstring-through-c-sharp
/// </summary>
namespace StellaArdens.Core.Util
{
    public class SortedObservableCollection<T> : ObservableCollection<T> where T : IComparable<T>
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            if (e.Action != NotifyCollectionChangedAction.Reset &&
                e.Action != NotifyCollectionChangedAction.Move &&
                e.Action != NotifyCollectionChangedAction.Remove)
            {
                var query = this.Select((item, index) => (Item: item, Index: index)).OrderBy(tuple => tuple.Item, Comparer.Default);
                var map = query.Select((tuple, index) => (OldIndex: tuple.Index, NewIndex: index)).Where(o => o.OldIndex != o.NewIndex);
                using (var enumerator = map.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        base.MoveItem(enumerator.Current.OldIndex, enumerator.Current.NewIndex);
                    }
                }
            }
        }

        // (optional) user is not allowed to move items in a sorted collection
        protected override void MoveItem(int oldIndex, int newIndex) => throw new InvalidOperationException();
        protected override void SetItem(int index, T item) => throw new InvalidOperationException();

        private class Comparer : IComparer<T>
        {
            public static readonly Comparer Default = new Comparer();

            public int Compare(T x, T y) => x.CompareTo(y);
        }
        // explicit sort; sometimes needed.
        public virtual void Sort()
        {
            if (Items.Count <= 1)
                return;

            var items = Items.ToList();
            Items.Clear();
            items.Sort();
            foreach (var item in items)
            {
                Items.Add(item);
            }
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

    }
}
