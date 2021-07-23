﻿using System;
using System.Collections.Generic;
using CodingEvents.Models;

namespace CodingEvents.Data
{
    public class EventData
    {

        //store events
        static private Dictionary<int, Event> _events = new Dictionary<int, Event>();

            //add events
        public static void Add(Event newEvent)
        {
            _events.Add(newEvent.Id, newEvent);
        }

            //retrieve events
        public static IEnumerable <Event> GetAll()
        {
            return _events.Values;
        }

        //retrieve a single event
        public static Event GetById(int id)
        {

            return _events[id];
        }

            //remove an event
        public static void Remove(int id)
        {
            _events.Remove(id);
        }
        
    }
}
