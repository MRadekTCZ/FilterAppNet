using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FilterRLC.Models
{

        public class FilterParams
        {
            public int ID { get; set; }
            //---
            [Display(Name = "Resistance 1 [Ohm]")]
            [Required(ErrorMessage = "Please enter resistance value")]
            [Range(0, 10000)]
            public double? Resistance_1 { get; set; }
            //---
            [Display(Name = "Resistance 2 [Ohm]")]
            [Required(ErrorMessage = "Please enter resistance value")]
            [Range(0, 10000)]
            public double? Resistance_2 { get; set; }
            //---
            [Display(Name = "Inductance [H]")]
            [Required(ErrorMessage = "Please enter inductance value")]
            [Range(0, 10)]
            public double? Inductance { get; set; }
            //---
            [Display(Name = "Capacitance [F]")]
            [Range(0, 2)]
            [Required(ErrorMessage = "Please enter capacitance value")]
            public double? Capacitance { get; set; }
            //---
            [Display(Name = "Amplitude of Input Voltage [V]")]
            [Required(ErrorMessage = "Please enter voltage input")]
            [Range(0, 150000)]
            public double? U1 { get; set; }
            //---
            [Display(Name = "Minimum Frequency [Hz]")]
            [Required(ErrorMessage = "Please enter minimum frequency")]
            [Range(0, 10000000000)]
            public double? Fmin { get; set; }
            //---
            [Display(Name = "Maximum Frequency [Hz]")]
            [Required(ErrorMessage = "Please enter maximum frequency")]
            [Range(0, 10000000000)]
            public double? Fmax { get; set; }
            //---
            [Display(Name = "Number Of Points")]
            [Required(ErrorMessage = "Please enter the number of waveform points")]
            [Range(20, 1000000)]
            public int? NumOfRows { get; set; }
            }
    }