using System;
using ClassPaper;
using EnumTime;

namespace LabResearch
{
    public class ResearchTeam
    {
        private string _theme;
        private string _organization;
        private int _registrationNumber;
        private TimeFrame _duration;
        private Paper[] _papers;

        public ResearchTeam(string theme, string organization, int registrationNumber, TimeFrame duration)
        {
            _theme = theme;
            _organization = organization;
            _registrationNumber = registrationNumber;
            _duration = duration;
            _papers = new Paper[0];
        }

        public ResearchTeam()
        {
            _theme = "Искусственный интеллект";
            _organization = "ИТМО";
            _registrationNumber = 101;
            _duration = TimeFrame.TwoYears;
            _papers = new Paper[0];
        }

        public string Theme
        {
            get => _theme;
            set => _theme = value;
        }

        public string Organization
        {
            get => _organization;
            set => _organization = value;
        }

        public int RegistrationNumber
        {
            get => _registrationNumber;
            set => _registrationNumber = value;
        }

        public TimeFrame Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public Paper[] Papers
        {
            get => _papers;
            set => _papers = value;
        }

        public Paper LatestPaper
        {
            get
            {
                if (_papers == null || _papers.Length == 0)
                    return null;

                Paper latest = _papers[0];
                foreach (var paper in _papers)
                {
                    if (paper.PublicationDate > latest.PublicationDate)
                    {
                        latest = paper;
                    }
                }
                return latest;
            }
        }

        // Индексатор булевского типа (только с get)
        public bool this[TimeFrame timeFrame]
        {
            get => _duration == timeFrame;
        }

        // Метод для добавления публикаций через params
        public void AddPapers(params Paper[] newPapers)
        {
            if (newPapers == null || newPapers.Length == 0) return;

            int oldLength = _papers.Length;
            Array.Resize(ref _papers, oldLength + newPapers.Length);

            for (int i = 0; i < newPapers.Length; i++)
            {
                _papers[oldLength + i] = newPapers[i];
            }
        }

        // Перегрузка ToString() со списком публикаций
        public override string ToString()
        {
            string papersStr = _papers.Length == 0 ? "Публикаций нет" : string.Join("\n  ", (object[])_papers);
            return $"Тема: {_theme}\nОрганизация: {_organization}\nРег. номер: {_registrationNumber}\nСрок: {_duration}\nПубликации:\n  {papersStr}";
        }

        // Виртуальный метод ToShortString() без списка публикаций
        public virtual string ToShortString()
        {
            return $"Тема: {_theme}, Организация: {_organization}, Рег. номер: {_registrationNumber}, Срок: {_duration}";
        }
    }

}
