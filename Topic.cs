using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nea_backend
{
    public enum _Topic
    {
        SubjectVerbAgreement = 1,
        ModalVerbs,
        ConditionalTense,
        Gerunds,
        Conjunctions,
        Tenses,
        ActivePassive,
        AdjectivesAdverbs,
        FractionsDecimalsPercentages,
        Algebra,
        Graphs,
        Inequalities,
        Sequences,
        Geometry,
        RatioProportion,
        SimultaneousEq,
        Probability,
        Quadratics,
        AveragesRangesModeMedian,
        PerimeterAreaVolume
    }

    public class Topic
    {
        private int topicId;
        private string topicName;
        private string videoLink;
        private Subject subject;

        public int TopicId { get { return topicId; } }
        public string TopicName { get { return topicName; } }
        public string VideoLink { get { return videoLink; } }
        public Subject Subject { get { return subject; } }

        public Topic(int topicId, string topicName, string videoLink, Subject subject)
        {
            this.topicId = topicId;
            this.topicName = topicName;
            this.videoLink = videoLink;
            this.subject = subject;
        }
    }
}
