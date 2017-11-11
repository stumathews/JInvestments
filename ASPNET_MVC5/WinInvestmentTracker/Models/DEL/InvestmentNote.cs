﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models.DEL
{
    public class InvestmentNote: IDbInvestmentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Title of the note
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Contents of the note
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// All notes will be in relation to an investment
        /// </summary>
        public virtual Investment Investment { get; set; }        

    }
}