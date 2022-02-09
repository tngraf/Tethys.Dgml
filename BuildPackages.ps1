# =========================================
# Build NuGet Packages for Tethys.Logging
#
# SPDX-License-Identifier: Apache-2.0
# SPDX-FileCopyrightText: 2021-2022 T. Graf
# =========================================

cd Tethys.Dgml
nuget pack Tethys.Dgml.nuspec
Move-Item Tethys.Dgml.*.nupkg .. -Force
cd ..


# ============================
# ============================
