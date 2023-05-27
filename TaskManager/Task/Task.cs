﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member;

namespace Elements
{
    public abstract class TaskElement
    {
        protected int _id;
        //protected State _currentState;
        protected string _description { get; set; }
        protected int _type;
        protected string _status { get; set; }
        protected string _title { get; set; }
        protected Member.Member currentAsignee;
        protected Member.Member reporter;

        protected int _projectId;
        // protected Button edit;

        public int ProjectId {
            get { return _projectId; }

        }
        public int Type
        {
            get { return _type; }

        }

        public TaskElement(int id, string description, int type, string title, string status,int projectId)
        {
            this._id = id;
            this._description = description;
            this._type = type;
            this._title = title;
            this._status = status;
            this._projectId = projectId;
        }
        public void TaskComplete() {

        }
        public int GetId()
        {
            return _id;
        }
        public string GetStatus()
        {
            return _status;
        }
        public void SetStatus(string status)
        {
            this._status = status;
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Member.Member CurrentAsignee {
            get { return currentAsignee; }
            set { currentAsignee = value; }
        }
        public Member.Member Reporter
        {
            get { return reporter; }
            set { reporter = value; }
        }
    }
}
